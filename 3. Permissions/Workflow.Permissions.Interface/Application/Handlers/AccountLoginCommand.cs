using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.Attributes;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Permissions.Interface.Presentation.ServicesDto;

namespace Workflow.Permissions.Interface.Application.Handlers
{
    public class AccountLoginCommand : ApplicationActionResult
    {
        public LoginDto LoginDto { get; private set; }

        [OutputCommandParameter]
        public bool ReturnValue { get; set; }

        public AccountLoginCommand(LoginDto loginDto)
        {
            LoginDto = loginDto;
            LoginDto.Success = false;
            LoginDto.ErrorNumber = ErrorNumbers.AccountLoginCommand;
            LoginDto.ErrorMessage = "AccountLoginCommand";
            Success = false;
            ErrorNumber = ErrorNumbers.AccountLoginCommand;
            ErrorMessage = "AccountLoginCommand";
            UserId = LoginDto.UserId;
        }
    }
}

