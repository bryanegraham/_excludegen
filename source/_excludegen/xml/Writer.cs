//
//  Copyright (c) 2012 Bryan Graham <bryanegraham@gmail.com>
//  
//  This software is provided 'as-is', without any express or implied
//  warranty. In no event will the authors be held liable for any damages
//  arising from the use of this software.
//  
//  Permission is granted to anyone to use this software for any purpose,
//  including commercial applications, and to alter it and redistribute it
//  freely, subject to the following restrictions:
//  
//     1. The origin of this software must not be misrepresented; you must not
//     claim that you wrote the original software. If you use this software
//     in a product, an acknowledgment in the product documentation would be
//     appreciated but is not required.
//  
//     2. Altered source versions must be plainly marked as such, and must not be
//     misrepresented as being the original software.
//  
//     3. This notice may not be removed or altered from any source
//     distribution.
//
using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ExcludeGenerator.xml
{
	class Writer
	{
		private string mFilename;
		private string mErrorMessage;
		
		public Writer(String filename)
		{
			mFilename = filename;
			mErrorMessage = "";
		}

		public ErrorCodes.XMLParserError WriteContext(ExcludeContext context)
		{
            StreamWriter file = null;

            try
            {
                file = new StreamWriter(mFilename);

                file.WriteLine("<excludeAssets>");
                WriteAssetTags(file, context.ExcludeClasses);
                file.WriteLine("</excludeAssets>");
                file.WriteLine("<includeAssets>");
                WriteAssetTags(file, context.IncludeClasses);
                file.WriteLine("</includeAssets>");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unable to write file, are you sure you have write permissions?\n" + ex.Message, "Error Writing File");
				mErrorMessage = ex.Message;

                if (null != file)
                {
					file.Close();
                }
                
                return ErrorCodes.XMLParserError.FileWriteError;
            }

            file.Close();
			return ErrorCodes.XMLParserError.NoError;
		}

		public string GetLastError ()
		{
			string lastError = mErrorMessage;
			mErrorMessage = "";

			return lastError;
		}

        private void WriteAssetTags(StreamWriter writer, List<String> classNames)
        {
            foreach (string className in classNames)
            {
                writer.WriteLine("    <asset name=\"" + className + "\" />");
            }
        }
	}
}
