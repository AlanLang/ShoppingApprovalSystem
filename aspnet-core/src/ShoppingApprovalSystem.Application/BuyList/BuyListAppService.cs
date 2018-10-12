using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ShoppingApprovalSystem.Authorization;
using ShoppingApprovalSystem.BuyList.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using ShoppingApprovalSystem.Authorization.Users;
using ShoppingApprovalSystem.Sessions.Dto;
using Abp.Runtime.Session;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingApprovalSystem.BuyList
{
    [AbpAuthorize(PermissionNames.Buy_Buylist)]
    public class BuyListAppService : AsyncCrudAppService< BuyList,BuyListDto, int, BuyPageResultRequestDto, CreatBuyListDto, UpdateBuyListDto>, IBuyAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Approver.Approver, int> _approverRepository;
        public BuyListAppService(
            IRepository<BuyList,int> repository,
            IRepository<Approver.Approver,int> approverRepository,
            UserManager userManager
            ) : base(repository)
        {
            _userManager = userManager;
            _approverRepository = approverRepository;
        }

        /// <summary>
        /// 获取所有需要审核的订单
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<BuyListDto>> GetBuysNeedCheck(string search,int type)
        {
            var logInUserId = AbpSession.GetUserId();
            var needCheckPerson = await _approverRepository.GetAllListAsync(m => m.ApproverId == logInUserId);
            var re = await Repository.GetAllListAsync();
            if (type == 0)
            {
                re = re.Where(m => needCheckPerson.ToList().Where(n => n.UserId == m.CreatorUserId).Any() && m.BuyState <= 1).WhereIf(!string.IsNullOrWhiteSpace(search),m=>m.BuyName.Contains(search)).ToList();
            }
            else {
                re = re.Where(m => needCheckPerson.ToList().Where(n => n.UserId == m.CreatorUserId).Any()).WhereIf(!string.IsNullOrWhiteSpace(search), m => m.BuyName.Contains(search)).ToList();
            }
            return new ListResultDto<BuyListDto>(ObjectMapper.Map<List<BuyListDto>>(re));
        }
        
        public override Task<BuyListDto> Create(CreatBuyListDto input)
        {

            var user = _userManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            // 购物申请的作者为当前登录的人
            input.BuyAuthor = user.Result.Surname + user.Result.Name;

            try
            {
                sendWX(input);
            }
            catch (Exception)
            {
            }

            return base.Create(input);
        }

        public override Task<BuyListDto> Update(UpdateBuyListDto input)
        {
            var user = _userManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            // 购物申请的作者为当前登录的人
            input.BuyAuthor = user.Result.Surname + user.Result.Name;
            return base.Update(input);
        }

        protected override IQueryable<BuyList> CreateFilteredQuery(BuyPageResultRequestDto input)
        {
            if (input.type == 0)
            {
                return Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.search), m => m.BuyName.Contains(input.search)).Where(m => m.CreatorUserId == AbpSession.GetUserId()).Where(m=>m.BuyState <=3 );
            }
            else {
                return Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.search), m => m.BuyName.Contains(input.search)).Where(m => m.CreatorUserId == AbpSession.GetUserId()).Where(m=>m.BuyState > 3);
            }

        }
        private readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }

        public HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, Encoding charset)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;
            //如果需要POST数据   
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = charset.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        private void sendWX(CreatBuyListDto input)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string url = "https://pushbear.ftqq.com/sub";
            parameters.Add("sendkey", "5342-293db690941b1677bc536a836f7167cf");
            parameters.Add("text", input.BuyName);
            parameters.Add("desp", $"您有一条新的购物申请\n\n购物名称：{input.BuyName}\n\n物品价格：{input.BuyPrice}\n\n购物地址：{input.BuyUrl}\n\n申请时间：{input.BuyTime}\n\n申请人：{input.BuyAuthor}\n\n本消息由[购物审批系统](http://langwenda.com:4200)自动发出，请勿回复。");
            Encoding encoding = Encoding.GetEncoding("utf-8");
            CreatePostHttpResponse(url, parameters, encoding);
        }
    }
}
