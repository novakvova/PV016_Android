package com.example.sim.service;

import com.example.sim.contants.Urls;
import com.example.sim.network.CategoriesApi;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class CategoryNetwork {
    private static CategoryNetwork instance;
    private Retrofit retrofit;

    public CategoryNetwork() {
        OkHttpClient httpClient = new OkHttpClient.Builder()
                .connectTimeout(20, TimeUnit.SECONDS)
                .writeTimeout(20, TimeUnit.SECONDS)
                .readTimeout(20, TimeUnit.SECONDS)
                .build();
        retrofit = new Retrofit.Builder()
                .client(httpClient)
                .baseUrl(Urls.BASE)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }
    public static CategoryNetwork getInstance() {
        if(instance==null)
            instance=new CategoryNetwork();
        return instance;
    }

    public CategoriesApi getJsonApi() {
        return retrofit.create(CategoriesApi.class);
    }
}
