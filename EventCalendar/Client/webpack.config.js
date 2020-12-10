const webpack = require("webpack"),
  dotenv = require("dotenv"),
  path = require("path");

module.exports = env => {
  const currentPath = path.join(__dirname);
  const basePath = currentPath + "/config/.env";
  const envPath = basePath + "." + env.ENVIRONMENT;
  dotenv.config({ path: envPath }).parsed;

  return {
    entry: ['@babel/polyfill', './src/index.js'], 
    module: {
      rules: [
        {
          test: /\.(js|jsx)$/,
          exclude: /node_modules/,
          use: {
            loader: "babel-loader"
          }
        },
        // {
        //   test: /\.tsx?$/,
        //   loader: "awesome-typescript-loader"
        // },
        {
          test: /\.css$/,
          use: [
            {
              loader: "style-loader"
            },
            {
              loader: "css-loader"
            }
          ]
        },
        {
          test: /\.js$/,
          enforce: 'pre',
          use: ['source-map-loader'],
        },
        {
          test: /\.js$/,
          enforce: 'pre',
          use: ['source-map-loader'],
        },
        {
          test: /\.(png|svg|jpg|jpeg|gif)$/,
          use: [
            {
              loader: "file-loader",
              options: {
                outputPath: "images",
                compact: true
              }
            }
          ]
        }
      ]
    },
    target: "web",
    resolve: {
      extensions: ["*", ".js", ".jsx"]
    },
    output: {
      path: __dirname + "/build",
      publicPath: process.env.Public_Path,
      filename: "bundle.js"
    },
    plugins: [
      new webpack.optimize.LimitChunkCountPlugin({
        maxChunks: 1
      }),
      new webpack.HotModuleReplacementPlugin()
    ],
    devServer: {
      contentBase: "./public",
      hot: true,
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "*",
        "Access-Control-Allow-Headers":
          "X-Requested-With, content-type, Authorization,Originm,Accept"
      }
    }
  };
};
