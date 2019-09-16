using System;

namespace AbstractFactory
{
    public abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool Disconnect();
        public abstract string State
        {
            get;
        }
    }

    public abstract class Command
    {
        public abstract void Execute(string query);
    }

    public class MssqlConnection : Connection
    {
        public override bool Connect()
        {
            Console.Write("SQL connection will open.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.Write("SQL connection will close.");
            return true;
        }

        public override string State
        {
            get { return "Open"; }

        }
    }

    public class OracleConnection : Connection
    {
        public override bool Connect()
        {
            Console.Write("Oracle connection will open.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.Write("Oracle connection will close.");
            return true;
        }

        public override string State
        {
            get { return "Open"; }

        }
    }

    public class MssqlCommand : Command
    {
        public override void Execute(string query)
        {
            Console.Write("SQL query execute.");
        }
    }

    public class OracleCommand : Command
    {
        public override void Execute(string query)
        {
            Console.Write("Oracle query execute.");
        }
    }

    public abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    public class MssqlFactory : DatabaseFactory
    {
        public override Connection CreateConnection()
        {
            return new MssqlConnection();
        }

        public override Command CreateCommand()
        {
            return new MssqlCommand();
        }
    }
    public class OracleFactory : DatabaseFactory
    {
        public override Connection CreateConnection()
        {
            return new OracleConnection();
        }

        public override Command CreateCommand()
        {
            return new OracleCommand();
        }
    }

    public class Factory
    {
        private DatabaseFactory _databaseFactory;
        private Connection _connection;
        private Command _command;

        public Factory(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;

            _connection = databaseFactory.CreateConnection();
            _command = databaseFactory.CreateCommand();

        }

        public void Start()
        {
            _connection.Connect();
            if (_connection.State == "Open")
            {
                _command.Execute("SELECT .....");
            }
        }
    }
}
