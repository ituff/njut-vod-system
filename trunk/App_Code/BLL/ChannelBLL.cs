using System.Data;
using System.Collections.Generic;

/// <summary>
///ChannelBLL 的摘要说明
/// </summary>
public class ChannelBLL
{
    public ChannelBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public DataSet Select()
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannels();
    }

    public DataSet SelectByUserId(int userId)
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannels(userId);
    }

    public channelinfo Select(int ChannelID)
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannel(ChannelID);
    
    }

    public channelinfo Select(string ChannelName)
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannel(ChannelName);

    }

    public bool Delete(string channelID)
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.delChannel(channelID);
    }

    public bool Update(channelinfo channel)
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.updateChannel(channel);
    }

    public bool Insert(channelinfo channel) {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.saveChannel(channel);
    }

    public DataSet getInternetLiveChannel() {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannels("WHERE isMobileLiveStream=0 ORDER BY ChannelID DESC LIMIT 9");
    }

    public DataSet getMobileLiveChannel()
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannels("WHERE isMobileLiveStream=1 ORDER BY ChannelID DESC LIMIT 9");
    }
   
       public DataSet getLiveChannel()
    {
        channelInfoDao channelDao = new channelInfoDao();
        return channelDao.getChannels("ORDER BY ChannelID DESC");
    }

       public List<channelinfo> getInternetLiveChannelList()
       {
           channelInfoDao channelDao = new channelInfoDao();
           return channelDao.getChannelList("WHERE isMobileLiveStream=0 ORDER BY ChannelID DESC");
       }

       public List<channelinfo> getMobileLiveChannelList()
       {
           channelInfoDao channelDao = new channelInfoDao();
           return channelDao.getChannelList("WHERE isMobileLiveStream=1 ORDER BY ChannelID DESC");
       }
}