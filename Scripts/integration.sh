#!/bin/sh
export EVENT_NOKQUEUE=1

unity='/Applications/Unity/Unity.app/Contents/MacOS/Unity'

echo "Start running Unity integration tests..."
$unity -batchmode \
    -verbose \
    -projectPath "$(pwd)/" \
    -runTests \
    -logFile "$(pwd)/output/playmode_log.xml" \
    -testResults "$(pwd)/output/playmode_results.xml" \
    -testPlatform "playmode"
result=$?
if [ $result -ne 0 ]; then
    echo "Unity integration tests failed."
    exit $result
fi