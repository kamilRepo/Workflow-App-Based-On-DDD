﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.DDD.Domain.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationLayerException(String message, string messageContent, ErrorNumbers errorNumber, int? userId)
            : base(message)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
        }

        public ApplicationLayerException(String messageContent, ErrorNumbers errorNumber, int? userId)
            : base(messageContent)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
        }

        public ErrorNumbers ErrorNumber { get; private set; }
        public string MessageContent { get; private set; }
        public int? UserId { get; private set; }
    }
}
