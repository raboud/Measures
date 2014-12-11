using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandREng.Types;

namespace MeasuresMVC.Tests.Types
{
	[TestClass]
	public class PhoneNumberRegEx
	{
		[TestMethod]
		public void PhoneNumber1()
		{
			string input = "234.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber2()
		{
			string input = "(234)567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber3()
		{
			string input = "(234) 567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber4()
		{
			string input = "234.567.8901 ext 9ii";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumber5()
		{
			string input = "aaa.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumber6()
		{
			string input = "234.567.8901 x 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}

		[TestMethod]
		public void PhoneNumber7()
		{
			string input = "234.567.8901 x8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber8()
		{
			string input = "234.567.8901x8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber9()
		{
			string input = "234.567.8901 ext. 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void XPhoneNumber10()
		{
			string input = "234.567.8901 ext8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber11()
		{
			string input = "234.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumber12()
		{
			string input = "234.567.8901 ";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumber13()
		{
			string input = "234.567.8901";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901");
		}
		[TestMethod]
		public void PhoneNumber14()
		{
			string input = "234.567-8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumber15()
		{
			string input = "24.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumber16()
		{
			string input = "234.567.8901";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901");
		}
	}
}
