#!/bin/sh
export EVENT_NOKQUEUE=1

unity='/Applications/Unity/Unity.app/Contents/MacOS/Unity'

echo "Start running Unity unit tests..."
$unity -batchmode \
    -verbose \
    -projectPath "$(pwd)/" \
    -runTests \
    -logFile "$(pwd)/output/editmode_log.xml" \
    -testResults "$(pwd)/output/editmode_results.xml" \
    -testPlatform "editmode"
result=$?
if [ $result -ne 0 ]; then
    echo "Unity unit tests failed."
    exit $result
fi