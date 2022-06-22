/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
	public partial class FUI_SamplePanel: GComponent
	{
		public enum c1_Page
		{
			Page_State1,
			Page_State2,
		}

		public Controller c1;
		public Controller c2;
		public GButton LoginBtn;
		public FUI_InputField1 AccountInput;
		public FUI_InputField1 PasswordInput;
		public GButton button2;
		public GLoader loader1;
		public GTextField Text1;
		public GRichTextField RichText1;
		public GImage image1;
		public GGraph Graph1;
		public GList List1;
		public GTextInput Input1;
		public GLoader3D Loader3D1;
		public GGroup Group2;
		public GButton Test2;
		public const string URL = "ui://rgfb0w498omm0";

		public static FUI_SamplePanel CreateInstance()
		{
			return (FUI_SamplePanel)UIPackage.CreateObject("Sample", "SamplePanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = GetControllerAt(0);
			c2 = GetControllerAt(1);
			LoginBtn = (GButton)GetChildAt(0);
			AccountInput = (FUI_InputField1)GetChildAt(1);
			PasswordInput = (FUI_InputField1)GetChildAt(2);
			button2 = (GButton)GetChildAt(3);
			loader1 = (GLoader)GetChildAt(4);
			Text1 = (GTextField)GetChildAt(5);
			RichText1 = (GRichTextField)GetChildAt(6);
			image1 = (GImage)GetChildAt(7);
			Graph1 = (GGraph)GetChildAt(8);
			List1 = (GList)GetChildAt(9);
			Input1 = (GTextInput)GetChildAt(10);
			Loader3D1 = (GLoader3D)GetChildAt(11);
			Group2 = (GGroup)GetChildAt(12);
			Test2 = (GButton)GetChildAt(14);
		}
	}
}
