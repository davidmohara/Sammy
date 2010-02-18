#!/usr/bin/env ruby

require 'scripts/msbuildtask'

CONFIG = 'Debug'
SOLUTION = 'bogart.sln'
PACKAGE_PATH = 'build/package'
HARVEST_TARGETS = ["Bogart"]

task :default => ['build:compile']
task :test => ['build:unit_test']

namespace :build do
  desc "Use MSBuild to build the solution: '#{SOLUTION}'"
  task :compile => [:msbuild] do
  end

  desc "Harvest build outputs to: '#{pwd}/#{PACKAGE_PATH}'"
  task :harvest => [:compile] do
	  rm_r PACKAGE_PATH if File.directory?(PACKAGE_PATH)
	  mkdir_p PACKAGE_PATH
	  HARVEST_TARGETS.each do |project|
		  location = "#{project}/bin/#{CONFIG}"
		  files = Dir.glob("#{location}/*.dll") + Dir.glob("#{location}/*.pdb")
		  files.each do |item|
			  puts "Copying #{item}..."
			  cp item, "#{PACKAGE_PATH}"
			end
	  end
  end
  
  desc "Grab dependencies"
  task :grab_deps do
	puts "Grabbing Kayak from built source..."
	cp_r "../kayak/build/package/", "libs/kayak"
  end

  Rake::MsbuildTask.new do |build|
  	build.config = CONFIG
  	build.cleanbefore = true
  	build.solutions = [SOLUTION]
  end
end
