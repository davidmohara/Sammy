#!/usr/bin/env ruby

require 'scripts/msbuildtask'

CONFIG = 'Debug'
SOLUTION = 'source/Sammy.sln'
PACKAGE_PATH = 'build/package'
HARVEST_TARGET_PROJECTS = ["Sammy"]
HARVEST_TARGET_EXTENSIONS = ["dll", "pdb", "exe"]

task :default => ['build:harvest']
task :test => ['build:unit_test']

namespace :build do
  desc "Use MSBuild to build the solution: '#{SOLUTION}'"
  task :compile => [:msbuild] do
  end

  desc "Harvest build outputs to: '#{pwd}/#{PACKAGE_PATH}'"
  task :harvest do #=> [:compile] do
	  rm_r PACKAGE_PATH if File.directory?(PACKAGE_PATH)
	  mkdir_p PACKAGE_PATH
	  HARVEST_TARGET_PROJECTS.each do |project|
		  location = "source/#{project}"
		  binaries = []
		  HARVEST_TARGET_EXTENSIONS.each do |ext|
			binaries += Dir.glob("#{location}/bin/*.#{ext}")
		  end
		  puts "Copying binaries..."
		  binaries.each do |item|
			  cp item, "#{PACKAGE_PATH}"
			end
		  puts "Copying all views..."
		  cp_r "#{location}/views", "#{PACKAGE_PATH}/views"
	  end
  end
  
  desc "Grab dependencies"
  task :grab_deps do
	puts "Grabbing Kayak from built source..."
	cp_r "../kayak/build/package", "libs/kayak"

	path = "../topshelf/build_output/"
	puts "Grabbing Topshelf from built source..."
	cp "#{path}Magnum.dll", "libs/topshelf"
	cp "#{path}Topshelf.dll", "libs/topshelf"
	cp "#{path}Topshelf.pdb", "libs/topshelf"
  end

  Rake::MsbuildTask.new do |build|
  	build.config = CONFIG
  	build.cleanbefore = true
  	build.solutions = [SOLUTION]
  end
end
