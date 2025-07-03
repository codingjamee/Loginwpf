using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RJ_Login_WPF.ViewModel
{
    class RelayCommand : ICommand
    {
        //버튼 클릭등의 명령 처리 위한 인터페이스
        //View와 ViewModel을 연결하는 핵심 요소e34

        //Fields
        private readonly Action<object> _executeAction; //매개변수 1개를 받고 반환값이 없는 델리게이트 //생성자에서만 값 할당 가능, 이후 변경 불가
        private readonly Predicate<object> _canExecuteAction; //매개변수 1개를 받고 bool을 반환하는 델리게이트

        //Constructors 1
        public RelayCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        //Constructors 2
        public RelayCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //명령 실행 가능 여부 변경될 때 발생
        //활성화 / 비활성화 상태 자동 업데이트

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
            //명령 실행가능한지 확인
            //true 버튼 활성화, false 버튼 비활성화
        }

        public void Execute(object parameter)
        {            //버튼 클릭 시 실행할 로직을 여기에 구현

            _executeAction?.Invoke(parameter);
        }

    }
}
