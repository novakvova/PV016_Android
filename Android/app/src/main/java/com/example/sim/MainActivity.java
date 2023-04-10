package com.example.sim;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ImageView iv = findViewById(R.id.imageView);
        String url = "https://pv016.allin.ml/images/1.jpg";
        Glide.with(this)
                .load(url)
                .apply(new RequestOptions().override(600))
                .into(iv);
    }
}