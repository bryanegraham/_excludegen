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
using System.ComponentModel;
using System.Text;
using SwfOp;

namespace ExcludeGenerator.xml
{

    public class ExcludeFile
    {
		public delegate void XMLErrorCallback(ErrorCodes.XMLParserError errCode, string message);

		string mSwfFileName;
        string mExcludeFileName;
        Reader mReader;
        Writer mWriter;
        ExcludeContext mContext;
		XMLErrorCallback mErrorCallback;

        public ExcludeContext Context
        {
            get { return mContext; }
        }

		public string FileName 
		{
			get { return mExcludeFileName; }
		}

		public ExcludeFile(string targetSwf, XMLErrorCallback errorCallback)
        {
            mSwfFileName = targetSwf;
            mExcludeFileName = targetSwf.Substring(0, targetSwf.IndexOf('.')) + "_exclude.xml";
			mErrorCallback = errorCallback;

            mReader = new Reader(mExcludeFileName);
            mWriter = new Writer(mExcludeFileName);
        }

        private List<String> GetLoadedClasses()
        {
            ContentParser swfParser = new ContentParser(mSwfFileName);
            swfParser.Run();

            List<DeclEntry> classesListRaw = swfParser.Classes;
            List<String> classNameList = new List<String>();

            foreach (DeclEntry rawClass in classesListRaw)
            {
                classNameList.Add(rawClass.Name);
            }

            return classNameList;
        }

		public void GenerateExcludeContext ()
		{
			mContext = new ExcludeContext ();
			ErrorCodes.XMLParserError result = mReader.ParseFile (mContext);
			if (result != ErrorCodes.XMLParserError.NoError)
			{
				mErrorCallback(result, "");
			}

            List<String> loadedClasses = GetLoadedClasses();

            foreach (String className in loadedClasses)
            {
                if (false == mContext.IncludeClasses.Contains(className))
                {
                    mContext.ExcludeClasses.Add(className);
                }
            }
        }

        public bool SaveContext()
        {
            ErrorCodes.XMLParserError verifyResult = mContext.VarifyConsistencyOK();
			if (verifyResult != ErrorCodes.XMLParserError.NoError)
			{
				mErrorCallback(verifyResult, "");
			}

			ErrorCodes.XMLParserError writeResult = mWriter.WriteContext(mContext);
			if (writeResult != ErrorCodes.XMLParserError.NoError)
			{
				mErrorCallback(writeResult, mWriter.GetLastError());
			}

			return (writeResult == ErrorCodes.XMLParserError.NoError);
        }
    }
}
