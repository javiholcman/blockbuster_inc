using System;
using System.Reflection;
using System.Windows.Input;

namespace BlockBuster
{
	public class Command : ICommand
	{
		//
		// Fields
		//
		private readonly Func<object, bool> _canExecute;

		private readonly Action<object> _execute;

		//
		// Constructors
		//
		public Command(Action execute, Func<bool> canExecute) : this(delegate (object o)
		{
			execute();
		}, (object o) => canExecute())
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			if (canExecute == null)
			{
				throw new ArgumentNullException("canExecute");
			}
		}

		public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
		{
			if (canExecute == null)
			{
				throw new ArgumentNullException("canExecute");
			}
			this._canExecute = canExecute;
		}

		public Command(Action execute) : this(delegate (object o)
		{
			execute();
		})
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
		}

		public Command(Action<object> execute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			this._execute = execute;
		}

		//
		// Methods
		//
		public bool CanExecute(object parameter)
		{
			return this._canExecute == null || this._canExecute(parameter);
		}

		public void ChangeCanExecute()
		{
			EventHandler canExecuteChanged = this.CanExecuteChanged;
			if (canExecuteChanged != null)
			{
				canExecuteChanged(this, EventArgs.Empty);
			}
		}

		public void Execute(object parameter)
		{
			this._execute(parameter);
		}

		public event EventHandler CanExecuteChanged;
	}

	public class Command<T> : Command
	{
		//
		// Constructors
		//
		public Command(Action<T> execute) : base(delegate (object o)
		{
			if (Command<T>.IsValidParameter(o))
			{
				execute((T)((object)o));
			}
		})
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
		}

		public Command(Action<T> execute, Func<T, bool> canExecute) : base(delegate (object o)
		{
			if (Command<T>.IsValidParameter(o))
			{
				execute((T)((object)o));
			}
		}, (object o) => Command<T>.IsValidParameter(o) && canExecute((T)((object)o)))
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			if (canExecute == null)
			{
				throw new ArgumentNullException("canExecute");
			}
		}

		//
		// Static Methods
		//
		private static bool IsValidParameter(object o)
		{
			if (o != null)
			{
				return o is T;
			}
			Type typeFromHandle = typeof(T);
			return Nullable.GetUnderlyingType(typeFromHandle) != null || !typeFromHandle.GetTypeInfo().IsValueType;
		}
	}
}
