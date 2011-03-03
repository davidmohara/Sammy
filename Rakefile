#!/usr/bin/env ruby

require 'albacore'

def expand(path)
  File.expand_path(File.dirname(__FILE__) + path)
end

CONFIG = 'Debug'
SOLUTION = expand('/Sammy.sln')
NUNIT_CONSOLE = expand('/lib/NUnit/nunit-console.exe')

TEST_DLLS = Dir.glob('*Test').collect{|dll| File.join(dll, 'bin', CONFIG, dll + '.dll')}

task :default => ['build:compile']
task :test => ['build:unit_test']

namespace :build do
  desc "Build the solution"
  msbuild :compile do |msb|
    msb.solution = SOLUTION
    msb.targets :Build
    msb.properties :configuration => CONFIG
  end

  desc "Run all tests"
  nunit :unit_test do |nunit|
    nunit.options '/exclude="Integration"'
    nunit.assemblies TEST_DLLS
    nunit.command = NUNIT_CONSOLE
  end
end
