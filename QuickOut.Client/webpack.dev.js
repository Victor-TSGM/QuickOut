import HtmlWebpackPlugin from 'html-webpack-plugin'
import { merge } from 'webpack-merge'
import common from './webpack.common.js'

export default merge(common, {
  mode: 'development',
  module: {
    rules: [{
      test: /\.ts(x?)$/,
      loader: 'ts-loader',
      options: {
        allowTsInNodeModules: true
      }
    }, {
      test: /\.(s?)css$/,
      use: [{
        loader: 'style-loader'
      }, {
        loader: 'css-loader'
      }]
    }]
  },
  devtool: 'inline-source-map',
  devServer: {
    historyApiFallback: true,
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './index.dev.html'
    })
  ]
})
