package com.zhy.csdndemo;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class TabAdapter extends FragmentPagerAdapter
{

	public static final String[] TITLES = new String[] { "业界", "移动", "研发", "程序员杂志", "云计算" };

	public TabAdapter(FragmentManager fm)
	{
		super(fm);
	}

	@Override
	public Fragment getItem(int arg0)
	{
		MainFragment fragment = new MainFragment(arg0+1);
		return fragment;
	}

	@Override
	public CharSequence getPageTitle(int position)
	{
		return TITLES[position % TITLES.length];
	}

	@Override
	public int getCount()
	{
		return TITLES.length;
	}

}
