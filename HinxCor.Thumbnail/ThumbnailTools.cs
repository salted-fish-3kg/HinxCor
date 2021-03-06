﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ThumbnailSharp;

public static class ThumbnailTools
{
    public enum Format
    {
        Jpeg = 0,
        Bmp = 1,
        Png = 2,
        Gif = 3,
        Tiff = 4,
    }

    //public static implicit operator ThumbnailSharp.Format(Format f)
    //{
    //    return ThumbnailSharp.Format.Bmp;
    //}

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="url">网络图像地址</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="kind">地址类型</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static byte[] GetNetImageThumbnailDataDirectly(string url, uint size = 250, UriKind kind = UriKind.Absolute, Format format = Format.Png)
    {
        var dat = GetNetImageThumbnailData(url, size, kind, format);
        return dat.GetAwaiter().GetResult();
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="url">网络图像地址</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="kind">地址类型</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static Stream GetNetImageThumbnailStreamDirectly(string url, uint size = 250, UriKind kind = UriKind.Absolute, Format format = Format.Png)
        => GetNetImageThumbnailStream(url, size, kind, format).GetAwaiter().GetResult();

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="url">网络图像地址</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="kind">地址类型</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public async static Task<byte[]> GetNetImageThumbnailData(string url, uint size = 250, UriKind kind = UriKind.Absolute, Format format = Format.Png)
    {
        return await new ThumbnailCreator().CreateThumbnailBytesAsync(
             thumbnailSize: size,
             urlAddress: new Uri(url, kind),
             imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="url">网络图像地址</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="kind">地址类型</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public async static Task<Stream> GetNetImageThumbnailStream(string url, uint size = 250, UriKind kind = UriKind.Absolute, Format format = Format.Png)
    {
        return await new ThumbnailCreator().CreateThumbnailStreamAsync(
             thumbnailSize: size,
             urlAddress: new Uri(url, kind),
             imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="fileName">图像文件名</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static byte[] GetLocalImageThumbnailData(string fileName, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailBytes(
                thumbnailSize: size,
                imageFileLocation: fileName,
                imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="fileName">图像文件名</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static Stream GetLocalImageThumbnailStream(string fileName, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailStream(
                thumbnailSize: size,
                imageFileLocation: fileName,
                imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="stream">图像数据流</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static byte[] GetStreamImageThumbnailData(Stream stream, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailBytes(
                 thumbnailSize: size,
                 imageStream: stream,
                 imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="stream">图像数据流</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static Stream GetStreamImageThumbnailStream(Stream stream, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailStream(
                thumbnailSize: size,
                imageStream: stream,
                imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="data">原图数据</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static byte[] GetByteArrayThumbnailData(byte[] data, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailBytes(
                 thumbnailSize: size,
                 imageBytes: data,
                 imageFormat: (ThumbnailSharp.Format)format);
    }

    /// <summary>
    /// 获取缩略图
    /// </summary>
    /// <param name="data">原图数据</param>
    /// <param name="size">缩略图宽度</param>
    /// <param name="format">缩略图数据格式</param>
    /// <returns>缩略图数据</returns>
    public static Stream GetByteArrayThumbnailStream(byte[] data, uint size = 250, Format format = Format.Png)
    {
        return new ThumbnailCreator().CreateThumbnailStream(
                thumbnailSize: size,
                imageBytes: data,
                imageFormat: (ThumbnailSharp.Format)format);
    }



}

