using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OneAll.Users;
using OneAll.Connections;

namespace OneAll.ASPNET
{
	public partial class Social : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.OneAllTokenExists())
			{
				// TODO: Implement your post login logic as below

				Guid oneAllUserToken = Guid.Empty;
				Guid oneAllCnToken = Request.OneAllToken();

				Response<ConnectionDetail> responseCn = OneAllAPI.Default.ConnectionReadDetails(oneAllCnToken);
				if (responseCn != null && responseCn.Result != null && responseCn.Result.Data != null)
				{
					ConnectionUser oneAllCnUser = responseCn.Result.Data.User;
					if (oneAllCnUser != null)
						oneAllUserToken = oneAllCnUser.UserToken;
				}
				else if (responseCn != null && responseCn.Request != null && responseCn.Request.Status != null)
				{
					_labelMessages.Text = string.Format("{0}: {1}: {2}", responseCn.Request.Status.Code, responseCn.Request.Status.Indicator, responseCn.Request.Status.Info);
				}

				if (!Guid.Empty.Equals(oneAllUserToken))
				{
					Response<UserResult> responseUser = OneAllAPI.Default.UserReadDetails(oneAllUserToken);
					if (responseUser != null && responseUser.Result != null && responseUser.Result.Data != null)
					{
						User oneAllUser = responseUser.Result.Data.User;
						if (oneAllUser != null && oneAllUser.Identities != null && oneAllUser.Identities[0] != null)
						{
							Identity oneAllId = oneAllUser.Identities[0];
							if (oneAllId != null)
							{
								_labelSocialName.Text = oneAllId.DisplayName;
								if (oneAllId.ThumbnailUrl != null)
									_imageSocialThum.ImageUrl = oneAllId.ThumbnailUrl.ToString();
							}
						}
					}
					else if (responseUser != null && responseUser.Request != null && responseUser.Request.Status != null)
					{
						_labelMessages.Text = string.Format("{0}: {1}: {2}", responseUser.Request.Status.Code, responseUser.Request.Status.Indicator, responseUser.Request.Status.Info);
					}
				}
			}
		}
	}
}
