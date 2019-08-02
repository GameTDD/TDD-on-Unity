#!/bin/sh

unity='/Applications/Unity/Unity.app/Contents/MacOS/Unity'

echo "Start building the project..."
$unity -batchmode \
    -projectPath "$(pwd)/src" \
    -logFile "$(pwd)/output/build_log.xml" \
    -buildOSXUniversalPlayer "$(pwd)/build/build.app" \
    -quit