package com.zhy.csdndemo.dao;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DBHelper extends SQLiteOpenHelper
{
	private static final String DB_NAME = "csdn_app_demo";

	public DBHelper(Context context)
	{
		super(context, DB_NAME, null, 1);
	}

	@Override
	public void onCreate(SQLiteDatabase db)
	{
		/**
		 * id,title,link,date,imgLink,content,newstype
		 */
		String sql = "create table tb_newsItem( _id integer primary key autoincrement , "
				+ " title text , link text , date text , imgLink text , content text , newstype integer  );";
		db.execSQL(sql);
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
	{
		// TODO Auto-generated method stub

	}

}
