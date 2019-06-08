/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;


namespace Reader
{
   public class STReader:IReader
    {
        public uint GetCode(byte sing)
        {
            int ret;
            uint snr = 0;
            TracingHelper.Info("send reader cardId");
            ret = API_RF.rf_card(sing, ref snr);
            TracingHelper.Info("recive sn="+snr);
            if (ret == 0)
                return snr;
            else return 0;
        }


        public void GetCode(byte sing,object context, Action<Exception, uint, object> callBack)
        {
            try
            {
                int ret;
                uint snr = 0;
                ret = API_RF.rf_card(sing, ref snr);
                if (ret == 0)
                    callBack(null, snr, context);
                else callBack(null, 0, context);
            }
            catch (Exception ex)
            {
                callBack(ex, 0, context);
            }
        }


        public void Beep(int time)
        {
            API_RF.rf_beep(time);
        }

        public void Halt()
        {
            API_RF.rf_halt();
        }

        public void PollReadCard(byte sing, object context, Action<Exception, uint, object> callBack)
        {
            throw new NotImplementedException();
        }

    }
}
