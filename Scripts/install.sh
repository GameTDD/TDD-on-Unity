#! /bin/sh

BASE_URL=http://netstorage.unity3d.com/unity
HASH=8afd630d1f5b

download() {
  file=$1
  url="$BASE_URL/$HASH/$package"

  echo "Downloading from $url: "
  curl -o `basename "$package"` "$url"
}

install() {
  package=$1
  download "$package"
  file=`basename "$package"`

  echo "Installing $file"
  sudo installer -dumplog -verbose -pkg "$file" -target /
}

install "MacEditorInstaller/Unity.pkg"
