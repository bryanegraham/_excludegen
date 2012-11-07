================================================================================
_excludegen

	Author: 		Bryan Graham <bryanegraham@gmail.com>
	Version: 		1.2
	Release Date: 	2012.11.06

================================================================================

-----------
Description
-----------

	Generates _exclude files for you. All you have to do is tick off what classes 
you want loaded into the swf, and everything else will be removed. Does a little
bit of magic so that subsequent uses of the plug-in won't require you to re-add 
the classes that you want to keep, so you can pretty much run it once, for the 
classes you want, and then generating its default results will work every time 
thereafter! Neato!

	As an added bonus I've exposed the API to the Exclude file class, which will
allows the features to be used if you provide your own frontend to 
"ExcludeGeneratior.xml.ExcludeFile." I'll add some documentation on this at some
point in the future.


------------
Installation
------------

 - Close FlashDevelop if it is currently running.
 - Extract the archive into your FlashDevelop install directory (Usually 
   something like: 'C:\Program Files(x86)\Flash Develop').
 - Restart FlashDevelop, right click on any swf file, and note the new menu 
   option.


-------------------------------
Known Bugs/Compatibility Issues
-------------------------------

 No known issues please report anything to the following url:
 https://bitbucket.org/bryanegraham/_excludegen/issues

---------------
Licensing/Legal
---------------

Copyright (c) 2012 Bryan Graham <bryanegraham@gmail.com>

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

   1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgement in the product documentation would be
   appreciated but is not required.

   2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.

   3. This notice may not be removed or altered from any source
   distribution.

----------
Change Log
----------

Version 1.2:
 - made xml.Reader a bit more tolerant to formatting errors, shouldn't throw any
   more fits when you have comments and/or blank lines
 - fixed an issue where exclude assets could overwrite include assets introduced
   in version 1.1

Version 1.1:
 - Cleaned up gui logic to remove duplicate entries is a less performance 
   impacting manner, and one more reliable than before

Version 1.0:
 - Initial Version
