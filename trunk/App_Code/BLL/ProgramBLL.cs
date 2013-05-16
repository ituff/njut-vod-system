using System.Data;
using System;
using System.Collections.Generic;

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
        return programDao.getPrograms();
    }

    public DataSet SelectByUserId(int userId)
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.getPrograms(userId);
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

    public DataSet getPrograms()
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.getPrograms( "ORDER BY ProgramID DESC LIMIT 9");
    }

    public DataSet getProgramsDESC()
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.getPrograms("ORDER BY ProgramID DESC");
    }

    public List<programinfo> getProgramList()
    {
        programInfoDao programDao = new programInfoDao();
        return programDao.getProgramList("ORDER BY ProgramID DESC");
    }

}