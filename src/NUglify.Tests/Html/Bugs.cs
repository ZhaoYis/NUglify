﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using NUglify.Html;
using NUnit.Framework;

namespace NUglify.Tests.Html
{
    [TestFixture]
    public class Bugs : TestHtmlParserBase
    {
        [Test]
        public void Bug73()
        {
            var settings = new HtmlSettings();

            input = @"
<p>para1</p>
<!-- <div class=""block__element--modifier"">something</div> -->
<h2>heading2</h2>
";
            equal(minify(input, settings), "<p>para1<h2>heading2</h2>");
        }
		
        [Test]
        public void Bug119()
        {
            input = "This is a fragment </p> and it continues here <a>";
            var htmlToText = Uglify.HtmlToText(input);
            equal("This is a fragment and it continues here  ", htmlToText.Code);
        }
    }
}