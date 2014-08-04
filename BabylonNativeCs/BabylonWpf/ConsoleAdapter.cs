using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    public class ConsoleAdapter : Web.Console
    {
        public void info(object message = null, params object[] optionalParams)
        {
            System.Diagnostics.Trace.WriteLine(string.Format(message.ToString(), optionalParams));
        }

        public void warn(object message = null, params object[] optionalParams)
        {
            System.Diagnostics.Trace.WriteLine(string.Format(message.ToString(), optionalParams));
        }

        public void error(object message = null, params object[] optionalParams)
        {
            System.Diagnostics.Debug.Fail(string.Format(message.ToString(), optionalParams));
        }

        public void log(object message = null, params object[] optionalParams)
        {
            System.Diagnostics.Trace.WriteLine(string.Format(message.ToString(), optionalParams));
        }

        public void profile(string reportName = null)
        {
            throw new NotImplementedException();
        }

        public void assert(bool test = false, string message = null, params object[] optionalParams)
        {
            throw new NotImplementedException();
        }

        public bool msIsIndependentlyComposed(Web.Element element)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public void dir(object value = null, params object[] optionalParams)
        {
            throw new NotImplementedException();
        }

        public void profileEnd()
        {
            throw new NotImplementedException();
        }

        public void count(string countTitle = null)
        {
            throw new NotImplementedException();
        }

        public void groupEnd()
        {
            throw new NotImplementedException();
        }

        public void time(string timerName = null)
        {
            throw new NotImplementedException();
        }

        public void timeEnd(string timerName = null)
        {
            throw new NotImplementedException();
        }

        public void trace()
        {
            throw new NotImplementedException();
        }

        public void group(string groupTitle = null)
        {
            throw new NotImplementedException();
        }

        public void dirxml(object value)
        {
            throw new NotImplementedException();
        }

        public void debug(string message = null, params object[] optionalParams)
        {
            throw new NotImplementedException();
        }

        public void groupCollapsed(string groupTitle = null)
        {
            throw new NotImplementedException();
        }

        public void select(Web.Element element)
        {
            throw new NotImplementedException();
        }
    }
}
