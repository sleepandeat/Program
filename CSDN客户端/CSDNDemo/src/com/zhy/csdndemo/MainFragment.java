package com.zhy.csdndemo;

import java.util.ArrayList;
import java.util.List;

import me.maxwin.view.IXListViewLoadMore;
import me.maxwin.view.IXListViewRefreshListener;
import me.maxwin.view.XListView;
import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;

import com.zhy.bean.CommonException;
import com.zhy.bean.NewsItem;
import com.zhy.biz.NewsItemBiz;
import com.zhy.csdn.Constaint;
import com.zhy.csdndemo.adapter.NewsItemAdapter;
import com.zhy.csdndemo.dao.NewsItemDao;
import com.zhy.csdndemo.util.AppUtil;
import com.zhy.csdndemo.util.Logger;
import com.zhy.csdndemo.util.NetUtil;
import com.zhy.csdndemo.util.ToastUtil;

@SuppressLint("ValidFragment")
public class MainFragment extends Fragment implements IXListViewRefreshListener, IXListViewLoadMore
{
	private static final int LOAD_MORE = 0x110;
	private static final int LOAD_REFREASH = 0x111;

	private static final int TIP_ERROR_NO_NETWORK = 0X112;
	private static final int TIP_ERROR_SERVER = 0X113;

	/**
	 * 是否是第一次进入
	 */
	private boolean isFirstIn = true;

	/**
	 * 是否连接网络
	 */
	private boolean isConnNet = false;

	/**
	 * 当前数据是否是从网络中获取的
	 */
	private boolean isLoadingDataFromNetWork;

	/**
	 * 默认的newType
	 */
	private int newsType = Constaint.NEWS_TYPE_YEJIE;
	/**
	 * 当前页面
	 */
	private int currentPage = 1;
	/**
	 * 处理新闻的业务类
	 */
	private NewsItemBiz mNewsItemBiz;

	/**
	 * 与数据库交互
	 */
	private NewsItemDao mNewsItemDao;

	/**
	 * 扩展的ListView
	 */
	private XListView mXListView;
	/**
	 * 数据适配器
	 */
	private NewsItemAdapter mAdapter;

	/**
	 * 数据
	 */
	private List<NewsItem> mDatas = new ArrayList<NewsItem>();

	/**
	 * 获得newType
	 * 
	 * @param newsType
	 */
	public MainFragment(int newsType)
	{
		this.newsType = newsType;
		Logger.e(newsType + "newsType");
		mNewsItemBiz = new NewsItemBiz();
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		return inflater.inflate(R.layout.tab_item_fragment_main, null);
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState)
	{
		super.onActivityCreated(savedInstanceState);
		mNewsItemDao = new NewsItemDao(getActivity());
		mAdapter = new NewsItemAdapter(getActivity(), mDatas);
		/**
		 * 初始化
		 */
		mXListView = (XListView) getView().findViewById(R.id.id_xlistView);
		mXListView.setAdapter(mAdapter);
		mXListView.setPullRefreshEnable(this);
		mXListView.setPullLoadEnable(this);
		mXListView.setRefreshTime(AppUtil.getRefreashTime(getActivity(), newsType));
		// mXListView.NotRefreshAtBegin();

		mXListView.setOnItemClickListener(new OnItemClickListener()
		{
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id)
			{
				NewsItem newsItem = mDatas.get(position-1);
				Intent intent = new Intent(getActivity(), NewsContentActivity.class);
				intent.putExtra("url", newsItem.getLink());
				startActivity(intent);
			}

		});
		if (isFirstIn)
		{
			/**
			 * 进来时直接刷新
			 */
			mXListView.startRefresh();
			isFirstIn = false;
		} else
		{
			mXListView.NotRefreshAtBegin();
		}
	}

	@Override
	public void onRefresh()
	{
		new LoadDatasTask().execute(LOAD_REFREASH);
	}

	@Override
	public void onLoadMore()
	{
		new LoadDatasTask().execute(LOAD_MORE);
	}

	/**
	 * 记载数据的异步任务
	 * 
	 * @author zhy
	 * 
	 */
	class LoadDatasTask extends AsyncTask<Integer, Void, Integer>
	{

		@Override
		protected Integer doInBackground(Integer... params)
		{
			switch (params[0])
			{
			case LOAD_MORE:
				loadMoreData();
				break;
			case LOAD_REFREASH:
				return refreashData();
			}
			return -1;
		}

		@Override
		protected void onPostExecute(Integer result)
		{
			switch (result)
			{
			case TIP_ERROR_NO_NETWORK:
				ToastUtil.toast(getActivity(), "没有网络连接！");
				mAdapter.setDatas(mDatas);
				mAdapter.notifyDataSetChanged();
				break;
			case TIP_ERROR_SERVER:
				ToastUtil.toast(getActivity(), "服务器错误！");
				break;

			default:
				break;

			}

			mXListView.setRefreshTime(AppUtil.getRefreashTime(getActivity(), newsType));
			mXListView.stopRefresh();
			mXListView.stopLoadMore();
		}

	}

	/**
	 * 下拉刷新数据
	 */
	public Integer refreashData()
	{

		if (NetUtil.checkNet(getActivity()))
		{
			
			isConnNet = true;
			// 获取最新数据
			try
			{
				List<NewsItem> newsItems = mNewsItemBiz.getNewsItems(newsType, currentPage);
				mAdapter.setDatas(newsItems);

				isLoadingDataFromNetWork = true;
				// 设置刷新时间
				AppUtil.setRefreashTime(getActivity(), newsType);
				// 清除数据库数据
				mNewsItemDao.deleteAll(newsType);
				// 存入数据库
				mNewsItemDao.add(newsItems);

			} catch (CommonException e)
			{
				e.printStackTrace();
				isLoadingDataFromNetWork = false;
				return TIP_ERROR_SERVER;
			}
		} else
		{Log.e("xxx", "no network");
			isConnNet = false;
			isLoadingDataFromNetWork = false;
			// TODO从数据库中加载
			List<NewsItem> newsItems = mNewsItemDao.list(newsType, currentPage);
			mDatas = newsItems;
			// mAdapter.setDatas(newsItems);
			return TIP_ERROR_NO_NETWORK;
		}

		return -1;

	}

	/**
	 * 会根据当前网络情况，判断是从数据库加载还是从网络继续获取
	 */
	public void loadMoreData()
	{
		// 当前数据是从网络获取的
		if (isLoadingDataFromNetWork)
		{
			currentPage += 1;
			try
			{
				List<NewsItem> newsItems = mNewsItemBiz.getNewsItems(newsType, currentPage);
				mNewsItemDao.add(newsItems);
				mAdapter.addAll(newsItems);
			} catch (CommonException e)
			{
				e.printStackTrace();
			}
		} else
		// 从数据库加载的
		{
			currentPage += 1;
			List<NewsItem> newsItems = mNewsItemDao.list(newsType, currentPage);
			mAdapter.addAll(newsItems);
		}

	}

}
