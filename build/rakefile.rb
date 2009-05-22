require 'rake/clean'
require 'fileutils'

CLEAN.include('artifacts','**/bin','**/obj')

deploy_dir = File.join('artifacts','deploy')

task :default => [:test]

task :init  => :clean do
	mkdir 'artifacts'
	mkdir 'artifacts/deploy'
end

task :compile => :init do
	framework_dir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', 'v3.5')
	msbuild_file = File.join(framework_dir, 'msbuild.exe')
	sh "#{msbuild_file} ../solution.sln /t:Clean /t:Build /property:Configuration=debug"
end

task :test, :needs => [:compile] do |t,args|
	file = File.expand_path("../product/project.specifications/bin/debug/project.specifications.dll")
	sh "../thirdparty/mbunit/mbunit.cons.exe #{file} /rt:text /rnf:project.specifications.dll-results /rf:artifacts /sr"
end

task :deploy => :compile do
	files =  File.join('../product','**','mars.rover*.exe')
	puts files
	Dir.glob(files).each do|file|
		puts file
		FileUtils.cp file,deploy_dir
	end
end

