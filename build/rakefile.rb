require 'rake/clean'
require 'fileutils'

class Project
	attr_reader :name 

	def self.name
		@name = "mars.rover"
	end 
end

class LocalSettings 
	attr_reader :settings
	def initialize
		@settings = {
			:xunit_report_file_dir => 'artifacts' ,
			:xunit_report_file_name => 'test_report',
			:xunit_report_type => 'text',
			:xunit_show_test_report => true,
			:debug => true,
		}
		@settings[:xunit_report_file_name_with_extension] = "#{@settings[:xunit_report_file_name]}.#{@settings[:xunit_report_type]}"
	end
end

class MbUnitRunner
	def initialize(items)
		@source_dir = items.fetch(:source_dir, 'product')
		@mbunit_dir = items.fetch(:mbunit_dir, 'thirdparty/mbunit')
		@test_results_dir = items.fetch(:test_results_dir, 'artifacts')
		@compile_target = items.fetch(:compile_target, 'debug')
		@category_to_exclude = items.fetch(:category_to_exclude, 'missing')
		@show_report = items.fetch(:show_report, true)
    @report_type = items.fetch(:report_type,'XML')
	end
	
	def execute_tests(assemblies)
		Dir.mkdir @test_results_dir unless exists?(@test_results_dir)
		
		assemblies.each do |assem|
      sh build_command_line_for(assem)
		end
	end

  def build_command_line_for(assembly)
			file = File.expand_path("#{@source_dir}/#{assembly}/bin/#{@compile_target}/#{assembly}.dll")
      "#{@mbunit_dir}/mbunit.cons.exe #{file} /rt:#{@report_type} /rnf:#{assembly}.dll-results /rf:#{@test_results_dir} #{'/sr' if @show_report} /ec:#{@category_to_exclude}"
  end
end

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v3.5')
		compile_target = attributes.fetch(:compile_target, 'debug')
	    solution_file = attributes[:solution_file]
		
		framework_dir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', 'v3.5')
		msbuild_file = File.join(framework_dir, 'msbuild.exe')
		
		sh "#{msbuild_file} #{solution_file} /property:Configuration=#{compile_target} /t:Rebuild"
	end
end

local_settings = LocalSettings.new

COMPILE_TARGET = 'debug'

CLEAN.include('artifacts','**/bin','**/obj')

project_test_dir  = File.join('product',"#{Project.name}.tests",'bin','debug')

deploy_dir = File.join('artifacts','deploy')

output_folders = [project_test_dir]

task :default => [:test]

task :init  => :clean do
  mkdir 'artifacts'
  mkdir 'artifacts/coverage'
  mkdir 'artifacts/deploy'
end

task :compile => :init do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => 'solution.sln'
end

task :deploy => :compile do
  Dir.glob(File.join('product','**','developwithpassion*.exe')).each do|file|
    FileUtils.cp file,File.join('artifacts','deploy')
  end
  FileUtils.cp develop_with_passion_bdddoc_logo, deploy_dir
  FileUtils.cp develop_with_passion_bdddoc_css, deploy_dir
end

task :test, :needs => [:compile] do |t,args|
  runner = MbUnitRunner.new :compile_target => COMPILE_TARGET, :category_to_exclude => args.category_to_exclude, :show_report => false
  runner.execute_tests ["#{Project.name}.tests"]
end
