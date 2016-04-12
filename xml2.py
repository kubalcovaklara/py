import urllib
import xml.etree.ElementTree as ET

url=("http://python-data.dr-chuck.net/comments_237634.xml")
data=urllib.urlopen(url).read()
tree=ET.fromstring(data)

count=0
commentlst=tree.findall(".//comment")
for item in commentlst:
    count=count+int(item.find("count").text)
print count