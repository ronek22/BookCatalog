using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Playback.Initialize();
            var bw = BrowserWindow.Launch(new Uri("https://localhost:44342"));
            bw.CloseOnPlaybackCleanup = false;
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            this.UIMap.Admin_LogsIn();
            this.UIMap.Admin_CreateFirstAuthor();
            this.UIMap.Admin_CreateSecondAuthor();
            this.UIMap.Admin_CreateFirstBookFirstAuthor();
            this.UIMap.Admin_CreateSecondBookFirstAuthor();
            this.UIMap.Admin_LogsOut_Moderator_LogsIn();
            this.UIMap.Moderator_UpdateAuthorFirstName();
            this.UIMap.Moderator_UpdateBook();
            this.UIMap.Moderator_LogsOut_User_LogsIn();
            this.UIMap.User_View_Details_Book();
            this.UIMap.User_View_Details_Author();
            this.UIMap.User_LogsOut_Admin_LogsIn();
            this.UIMap.Admin_DeleteBook();
            this.UIMap.Admin_DeleteAllAuthors();
            this.UIMap.Admin_LogsOut();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
