﻿using CCC.TestApp.Core.Application.DALInterfaces;

namespace CCC.TestApp.Core.Application.Usecases.Users
{
    public class CreateUserInteractor : UserInteractor, IRequestBoundary<CreateUserRequestModel>
    {
        readonly IResponseBoundary<CreateUserResponseModel> _responder;

        public CreateUserInteractor(IUserRepository userRepository, IResponseBoundary<CreateUserResponseModel> responder)
            : base(userRepository) {
            _responder = responder;
        }

        public void Invoke(CreateUserRequestModel inputModel) {
            _responder.Respond(new CreateUserResponseModel());
        }
    }

    public struct CreateUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public struct CreateUserResponseModel {}
}