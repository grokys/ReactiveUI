﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using Xunit;
using Splat;

#if !MONO
using ReactiveUI.Xaml;
#endif

namespace ReactiveUI.Tests
{
    public class RxAppTest
    {
#if !MONO
        [Fact]
        public void DepPropNotifierShouldBeFound()
        {
            Assert.True(RxApp.Locator.GetServices<ICreatesObservableForProperty>()
                .Any(x => x is DependencyObjectObservableForProperty));
        }
#endif

        [Fact]
        public void SchedulerShouldBeCurrentThreadInTestRunner()
        {
            Console.WriteLine(RxApp.MainThreadScheduler.GetType().FullName);
            Assert.Equal(CurrentThreadScheduler.Instance, RxApp.MainThreadScheduler);
        }
    }
}
