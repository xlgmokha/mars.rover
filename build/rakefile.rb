require 'rake/clean'
require 'fileutils'

class MbUnitRunner
	def initialize
		@mbunit_dir = '../thirdparty/mbunit'
		@test_results_dir = 'artifacts'
		@compile_target = 'debug'
		@show_report = true
		@report_type = 'text'
	end
	
	def execute_tests(assemblies)
		assemblies.each do |assem|
		  sh build_command_line_for(assem)
		end
	end

	def build_command_line_for(assembly)
		file = File.expand_path("../product/#{assembly}/bin/#{@compile_target}/#{assembly}.dll")
		"#{@mbunit_dir}/mbunit.cons.exe #{file} /rt:#{@report_type} /rnf:#{assembly}.dll-results /rf:#{@test_results_dir} #{'/sr' if @show_report}"
	end
end

CLEAN.include('artifacts','**/bin','**/obj')

project_test_dir  = File.join('product',"mars.rover.tests",'bin','debug')
deploy_dir = File.join('artifacts','deploy')

task :default => [:test]

task :init  => :clean do
  mkdir 'artifacts'
  mkdir 'artifacts/deploy'
end

task :compile => :init do
	framework_dir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', 'v3.5')
	msbuild_file = File.join(framework_dir, 'msbuild.exe')
	
	sh "#{msbuild_file} ../solution.sln /property:Configuration=debug /t:Rebuild"
end

task :test, :needs => [:compile] do |t,args|
  runner = MbUnitRunner.new
  runner.execute_tests ["project.specifications"]
end

task :deploy => :compile do
  Dir.glob(File.join('product','**','mars.rover*.exe')).each do|file|
    FileUtils.cp file,deploy_dir
  end
end

