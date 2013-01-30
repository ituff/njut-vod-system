using System.Data;

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

}