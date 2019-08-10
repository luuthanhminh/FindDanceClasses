using System;
using FindDanceClasses.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace FindDanceClasses.UI.Presenter
{
    public class AppCustomPresenter : MvxFormsPagePresenter
    {
        public AppCustomPresenter(IMvxFormsViewPresenter platformPresenter) : base(platformPresenter)
        {
        }

        public override MvxBasePresentationAttribute GetPresentationAttribute(MvxViewModelRequest request)
        {
            var att = base.GetPresentationAttribute(request);

            if (request.PresentationValues != null)
            {
                if (request.PresentationValues.ContainsKey(PresentationConstant.CLEAR_STACK_AND_SHOW_PAGE))
                {
                    ((MvxPagePresentationAttribute)att).NoHistory = true;
                }
            }

            return att;
        }
    }
}
