﻿using Caliburn.Micro;
using CCC.TestApp.Core.Application.Events;
using CCC.TestApp.Core.Application.Services;
using CCC.TestApp.Core.Application.Usecases;
using CCC.TestApp.Core.Application.Usecases.Users;
using CCC.TestApp.UI.Desktop.Controllers;
using CCC.TestApp.UI.Desktop.Models;

namespace CCC.TestApp.UI.Desktop.ViewModels.Users
{
    public class ShowUserViewModel : ScreenBase, IResponseBoundary<ShowUserResponseModel>,
        IResponseBoundary<DestroyUserResponseModel>, IHandle<UserRecordUpdated>
    {
        readonly UsersController _controller;
        readonly IMapper _mapper;
        UserModel _user;

        public ShowUserViewModel(UsersController controller, IMapper mapper) {
            _controller = controller;
            _mapper = mapper;
            base.DisplayName = "Show User";
        }

        public UserModel User {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public void Handle(UserRecordUpdated message) {
            if (message.Id == User.Id)
                _controller.RefreshUser(User.Id, this);
        }

        public void Respond(DestroyUserResponseModel model) {
            TryClose();
        }

        public void Respond(ShowUserResponseModel model) {
            User = _mapper.DynamicMap<UserModel>(model);
        }

        public void Destroy() {
            _controller.DestroyUser(_user.Id, this);
        }

        public void Edit() {
            _controller.EditUser(_user.Id);
        }
    }
}