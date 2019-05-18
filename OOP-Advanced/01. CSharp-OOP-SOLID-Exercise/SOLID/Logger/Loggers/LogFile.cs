using LoggerProject.Loggers.Contracts;
using System.Text;

namespace LoggerProject.Loggers
{
    public class LogFile : ILogFile
    {
        private StringBuilder loggedMessages;

        public LogFile()
        {
            loggedMessages = new StringBuilder();
            this.Size = 0;
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.UpdateSize(message);

            loggedMessages.AppendLine(message);
        }

        private void UpdateSize(string message)
        {
            int size = 0;

            foreach (var character in message)
            {
                if (char.IsLetter(character))
                {
                    size += (int)character;
                }
            }

            this.Size += size;
        }
    }
}
