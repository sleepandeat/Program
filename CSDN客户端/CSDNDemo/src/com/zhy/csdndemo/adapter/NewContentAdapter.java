package com.zhy.csdndemo.adapter;

import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.graphics.Bitmap;
import android.text.Html;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;
import com.nostra13.universalimageloader.core.assist.ImageScaleType;
import com.nostra13.universalimageloader.core.display.FadeInBitmapDisplayer;
import com.zhy.bean.News;
import com.zhy.bean.News.NewsType;
import com.zhy.csdndemo.R;

public class NewContentAdapter extends BaseAdapter
{
	private LayoutInflater mInflater;
	private List<News> mDatas = new ArrayList<News>();

	private ImageLoader imageLoader = ImageLoader.getInstance();
	private DisplayImageOptions options;

	public NewContentAdapter(Context context)
	{
		mInflater = LayoutInflater.from(context);

		imageLoader.init(ImageLoaderConfiguration.createDefault(context));
		options = new DisplayImageOptions.Builder().showStubImage(R.drawable.images)
				.showImageForEmptyUri(R.drawable.images).showImageOnFail(R.drawable.images).cacheInMemory()
				.cacheOnDisc().imageScaleType(ImageScaleType.EXACTLY).bitmapConfig(Bitmap.Config.RGB_565)
				.displayer(new FadeInBitmapDisplayer(300)).build();
	}

	public void addList(List<News> datas)
	{
		mDatas.addAll(datas);
	}

	@Override
	public int getCount()
	{
		return mDatas.size();
	}

	@Override
	public Object getItem(int position)
	{
		return mDatas.get(position);
	}

	@Override
	public long getItemId(int position)
	{
		return position;
	}

	@Override
	public int getItemViewType(int position)
	{
		switch (mDatas.get(position).getType())
		{
		case NewsType.TITLE:
			return 0;
		case NewsType.SUMMARY:
			return 1;
		case NewsType.CONTENT:
			return 2;
		case NewsType.IMG:
			return 3;
		case NewsType.BOLD_TITLE:
			return 4;
		}
		return -1;
	}

	@Override
	public int getViewTypeCount()
	{
		return 5;
	}

	@Override
	public boolean isEnabled(int position)
	{
		switch (mDatas.get(position).getType())
		{
		case NewsType.IMG:
			return true;
		default:
			return false;
		}
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		News news = mDatas.get(position); // 获取当前项数据

		Log.e("xxx", news.toString());

		ViewHolder holder = null;
		if (null == convertView)
		{
			holder = new ViewHolder();
			switch (news.getType())
			{
			case NewsType.TITLE:
				convertView = mInflater.inflate(R.layout.news_content_title_item, null);
				holder.mTextView = (TextView) convertView.findViewById(R.id.text);
				break;
			case NewsType.SUMMARY:
				convertView = mInflater.inflate(R.layout.news_content_summary_item, null);
				holder.mTextView = (TextView) convertView.findViewById(R.id.text);
				break;
			case NewsType.CONTENT:
				convertView = mInflater.inflate(R.layout.news_content_item, null);
				holder.mTextView = (TextView) convertView.findViewById(R.id.text);
				break;
			case NewsType.IMG:
				convertView = mInflater.inflate(R.layout.news_content_img_item, null);
				holder.mImageView = (ImageView) convertView.findViewById(R.id.imageView);
				break;
			case NewsType.BOLD_TITLE:
				convertView = mInflater.inflate(R.layout.news_content_bold_title_item, null);
				holder.mTextView = (TextView) convertView.findViewById(R.id.text);
				break;
			}
			convertView.setTag(holder);
		} else
		{
			holder = (ViewHolder) convertView.getTag();
		}

		if (null != news)
		{
			switch (news.getType())
			{
			case NewsType.IMG:
				imageLoader.displayImage(news.getImageLink(), holder.mImageView, options);
				break;
			case NewsType.TITLE:
				holder.mTextView.setText(news.getTitle());
				break;
			case NewsType.SUMMARY:
				holder.mTextView.setText(news.getSummary());
				break;
			case NewsType.CONTENT:
				holder.mTextView.setText("\u3000\u3000"+Html.fromHtml(news.getContent()));
				break;
			case NewsType.BOLD_TITLE:
				holder.mTextView.setText("\u3000\u3000"+Html.fromHtml(news.getContent()));
			default:

				// holder.mTextView.setText(Html.fromHtml(item.getContent(),
				// null, new MyTagHandler()));
				// holder.content.setText(Html.fromHtml("<ul><bold>加粗</bold>sdfsdf<ul>",
				// null, new MyTagHandler()));
				break;
			}
		}
		return convertView;
	}

	private final class ViewHolder
	{
		TextView mTextView;
		ImageView mImageView;
	}
}
