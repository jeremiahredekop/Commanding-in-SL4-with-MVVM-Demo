using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandingWithMvvm.ViewModels;

namespace SilverlightTest1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestViewModelIncrements()
        {
            Binding1ViewModel vm = new Binding1ViewModel();
            int initialValue = vm.Count;
            // execute command
            vm.IncrementCount.Execute(null);

            // check that incrementing happened
            initialValue++;
            Assert.AreEqual(initialValue, vm.Count);


        }
    }
}