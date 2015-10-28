package com.zhy.test;

import java.util.List;

import com.zhy.bean.CommonException;
import com.zhy.bean.NewsItem;
import com.zhy.biz.NewsItemBiz;
import com.zhy.csdn.Constaint;
import com.zhy.csdn.DataUtil;

public class Test
{

	@org.junit.Test
	public void test01()
	{
		NewsItemBiz biz = new NewsItemBiz();
		int currentPage = 1;
		try
		{
			/**
			 * 业界
			 */
			List<NewsItem> newsItems = biz.getNewsItems(Constaint.NEWS_TYPE_YEJIE, currentPage);
			for (NewsItem item : newsItems)
			{
				System.out.println(item);
			}

			System.out.println("----------------------");
			/**
			 * 程序员杂志
			 */
			newsItems = biz.getNewsItems(Constaint.NEWS_TYPE_CHENGXUYUAN, currentPage);
			for (NewsItem item : newsItems)
			{
				System.out.println(item);
			}
			System.out.println("----------------------");
			/**
			 * 研发
			 */
			newsItems = biz.getNewsItems(Constaint.NEWS_TYPE_YANFA, currentPage);
			for (NewsItem item : newsItems)
			{
				System.out.println(item);
			}
			System.out.println("----------------------");
			/**
			 * 移动
			 */
			newsItems = biz.getNewsItems(Constaint.NEWS_TYPE_YIDONG, currentPage);
			for (NewsItem item : newsItems)
			{
				System.out.println(item);
			}
			System.out.println("----------------------");

		} catch (CommonException e)
		{
			e.printStackTrace();
		}
	}

}
