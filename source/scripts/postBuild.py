#
#	postBuild.py
#

#
#	imports
#
import shutil;
import os;

#
#	constants
#
BUILD_TARGET_DLL = "ExcludeGenerator.dll"
OUTPUT_DIRECTORY = "bin\\"
FLASH_DEVELOP_PLUGIN_PATH = "C:\\Program Files (x86)\\FlashDevelop\\Plugins\\"

#
#	main
#
if "__main__" == __name__:
	outdir = os.path.join(os.getcwd(), OUTPUT_DIRECTORY)

	source = outdir + BUILD_TARGET_DLL
	dest = FLASH_DEVELOP_PLUGIN_PATH + BUILD_TARGET_DLL
	
	print "source: " + source
	print "dest:   " + dest
	
	try:
		shutil.copy2(source, dest)
		print "Copy target succeeded!"
		exit(0)
	except Exception as exception:
		print "Copy target Failed:"
		print str(exception)
		exit(-1)
	#
#
