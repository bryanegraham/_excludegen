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
using System.Windows.Forms;
using System.Collections.Generic;
using PluginCore.Helpers;
using System.IO;
using System.Diagnostics;

namespace ExcludeGenerator.xml
{
	class Reader
	{
		private const string kExcludeTag = "excludeAssets";
		private const string kIncludeTag = "includeAssets";
		private const string kAssetTag = "asset";
		private const string kNameTag = "name";

		private string mFileName;

		public Reader(string fileName)
		{
			mFileName = fileName;
		}

		public ErrorCodes.XMLParserError ParseFile(ExcludeContext context)
		{
			if (File.Exists(mFileName))
			{
                StreamReader file = null;

				try
				{
                    file = new StreamReader(mFileName);
                    
                    bool excludeOpened = false;
                    bool excludeClosed = false;
                    bool includeOpened = false;
                    bool includeClosed = false;

                    while (file.Peek() != -1)
                    {
                        string line = file.ReadLine();

                        if (line == "<excludeAssets>")
                        {
                            excludeOpened = true;
                        }
                        else if (line == "</excludeAssets>")
                        {
                            excludeClosed = true;
                        }
                        else if (line == "<includeAssets>")
                        {
                            includeOpened = true;
                        }
                        else if (line == "</includeAssets>")
                        {
                            includeClosed = true;
                        }
                        else if (line.Contains(kAssetTag))
                        {
                            int firstQuote = line.IndexOf('\"');
                            int lastQuote = line.LastIndexOf('\"');

                            int classNameLength = lastQuote - firstQuote;
                            string className = line.Substring(firstQuote + 1, classNameLength - 1);


                            if (excludeOpened && !excludeClosed)
                            {
                                context.ExcludeClasses.Add(className);
                            }
                            else if (includeOpened && !includeClosed)
                            {
                                context.IncludeClasses.Add(className);
                            }
                        }
                        else
                        {
                            throw new System.Exception();
                        }
                    }
				}
				catch (System.Exception ex)
                    // Since this is not a proper XML file we can be pretty loose on error 
                    // handling, if there is any error, we'll just spit out this generic error message
				{
                    // Close reader
					file.Close();
					return ErrorCodes.XMLParserError.TagReadError;
				}

				file.Close();
				context.VarifyConsistencyOK();
			}
			else
			{
				return ErrorCodes.XMLParserError.InputFileDoesNotExist;
			}

			return ErrorCodes.XMLParserError.NoError;
		}
	}
}
