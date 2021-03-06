﻿using Util.Controls.Builders.Tags;
//using Util.Logs;

namespace Util.Controls.Base {
    /// <summary>
    /// 组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    public abstract class ComponentBase<T> : IComponent<T> where T : IComponent<T> {
        /// <summary>
        /// 标识
        /// </summary>
        private string _id;

        private TagBuilder _builder;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder Builder {
            get { return _builder ?? ( _builder = GetTagBuilder() ); }
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TagBuilder GetTagBuilder();

        /// <summary>
        /// 返回组件本身
        /// </summary>
        protected T This() {
            return (T)( (object)this );
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        protected string GetAttributeValue( string name ) {
            return Builder.Get( name );
        }

        /// <summary>
        /// 获取class值
        /// </summary>
        protected string GetClass() {
            return Builder.Get( "class" );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public T AddAttribute( string name, string value ) {
            Builder.AddAttribute( name, value );
            return This();
        }

        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public T UpdateAttribute( string name, string value ) {
            Builder.UpdateAttribute( name, value );
            return This();
        }

        /// <summary>
        /// 添加style属性
        /// </summary>
        /// <param name="name">style属性名</param>
        /// <param name="value">style属性值</param>
        public T AddStyle( string name, string value ) {
            Builder.AddStyle( name, value );
            return This();
        }

        /// <summary>
        /// 添加data-toggle属性值
        /// </summary>
        /// <param name="value">属性值</param>
        public T AddDataToggle( string value ) {
            Builder.AddDataAttribute( "toggle", value );
            return This();
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        /// <param name="isAddQuote">是否为值添加引号</param>
        public T AddDataOption( string name, string value, bool isAddQuote = false ) {
            Builder.AddDataOption( name, value, isAddQuote );
            return This();
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public T AddDataOption( string name, bool value ) {
            Builder.AddDataOption( name, value );
            return This();
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public T AddDataOption( string name, bool? value ) {
            Builder.AddDataOption( name, value );
            return This();
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public T AddDataOption( string name, int value ) {
            return AddDataOption( name, value.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public T AddDataOption( string name, int? value ) {
            return AddDataOption( name, value.ToStr() );
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public T Class( string @class ) {
            Builder.AddClass( @class );
            return This();
        }

        /// <summary>
        /// 更新class属性
        /// </summary>
        /// <param name="class">class属性</param>
        public T UpdateClass( string @class ) {
            Builder.UpdateClass( @class );
            return This();
        }

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">标识</param>
        public T Id( string id ) {
            _id = id;
            return UpdateAttribute( "id", id );
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="isPercent">是否百分比</param>
        public virtual T Width( int? width, bool isPercent = false ) {
            if ( width == null )
                return This();
            return AddStyle( "width", GetUnitValue( width.ToStr(), isPercent ) );
        }

        /// <summary>
        /// 获取带像素或百分比的值
        /// </summary>
        private string GetUnitValue( string value, bool isPercent = false ) {
            return string.Format( "{0}{1}", value, isPercent ? "%" : "px" );
        }

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        public T Height( int height ) {
            return AddStyle( "height", GetUnitValue( height.ToString() ) );
        }

        /// <summary>
        /// 设置外边距
        /// </summary>
        /// <param name="value">外边距值，四边相同</param>
        public T Margin( int value ) {
            return AddStyle( "margin", GetUnitValue( value.ToString() ) );
        }

        /// <summary>
        /// 设置外边距
        /// </summary>
        /// <param name="topBottom">上下边距值</param>
        /// <param name="leftRight">左右边距值</param>
        public T Margin( int topBottom, int leftRight ) {
            return AddStyle( "margin", string.Format( "{0}px {1}px", topBottom, leftRight ) );
        }

        /// <summary>
        /// 设置外边距
        /// </summary>
        /// <param name="top">上边距值</param>
        /// <param name="right">右边距值</param>
        /// <param name="bottom">下边距值</param>
        /// <param name="left">左边距值</param>
        public T Margin( int top, int right, int bottom, int left ) {
            return AddStyle( "margin", string.Format( "{0}px {1}px {2}px {3}px", top, right, bottom, left ) );
        }

        /// <summary>
        /// 设置内边距
        /// </summary>
        /// <param name="value">内边距值,四边相同</param>
        public T Padding( int value ) {
            return AddStyle( "padding", GetUnitValue( value.ToString() ) );
        }

        /// <summary>
        /// 设置内边距
        /// </summary>
        /// <param name="topBottom">上下边距值</param>
        /// <param name="leftRight">左右边距值</param>
        public T Padding( int topBottom, int leftRight ) {
            return AddStyle( "padding", string.Format( "{0}px {1}px", topBottom, leftRight ) );
        }

        /// <summary>
        /// 设置内边距
        /// </summary>
        /// <param name="top">上边距值</param>
        /// <param name="right">右边距值</param>
        /// <param name="bottom">下边距值</param>
        /// <param name="left">左边距值</param>
        public T Padding( int top, int right, int bottom, int left ) {
            return AddStyle( "padding", string.Format( "{0}px {1}px {2}px {3}px", top, right, bottom, left ) );
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        public string GetId() {
            return _id;
        }

        /// <summary>
        /// 输出Html
        /// </summary>
        public string ToHtmlString() {
            RenderBefore();
            var result = Render();
            RenderAfter( result );
            return result;
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        protected virtual void RenderBefore() {
        }

        /// <summary>
        /// 渲染操作
        /// </summary>
        protected virtual string Render() {
            return Builder.ToString();
        }

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="result">渲染结果</param>
        protected virtual void RenderAfter( string result ) {
            //WriteLog( result );
        }

        ///// <summary>
        ///// 写日志
        ///// </summary>
        //private void WriteLog( string result ) {
        //    var log = GetLog();
        //    if( !log.IsDebugEnabled )
        //        return;
        //    log.Class( this.GetType().FullName ).Content( result ).Debug();
        //}

        ///// <summary>
        ///// 获取日志组件
        ///// </summary>
        //protected virtual ILog GetLog() {
        //    return Log.GetLog( Config.ControlTraceLogName );
        //}

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToString() {
            return ToHtmlString();
        }
    }
}
