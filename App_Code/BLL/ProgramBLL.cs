using System.Data;
using System;

/// <summary>
///ProgramBLL 的摘要说明
/// </summary>
public class ProgramBLL
{
    public ProgramBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public DataSet Select()
    {
        programInfoDao programDao = new programInfoDao();
        channelInfoDao channelDao = new channelInfoDao();
        return programDao.getPrograms();
    }

    public programinfo Select(int ProgramID)
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.getProgram(ProgramID);
    }

    public bool Delete(string programID)
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.delProgram(programID);
    }

    public bool Update(programinfo program)
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.updateProgram(program);
    }

    public bool Insert(programinfo program)
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.saveProgram(program);
    }

}