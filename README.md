# UnrealNode

UnrealNode是一个在Unreal UBT的基础上实现的一个类似Node.js的运行架构（可以看做一个node.js在图形学领域的一个变种）

特性：
1.兼容nodejs(纯js库可以直接用，c+库使用upm编译)
2.内置unreal对象
3.预置常用c++组件（多为图形处理相关）
4.原生支持ts
5.支持用blueprint写逻辑


编译说明：

1.本项目高度依赖unreal源码 需要放在UnrealEngine\Engine\Source\Programs下 ，使用GenerateProjectFiles.bat重新.sln后才能编译

2.ThirdParty文件比较大（包含v8在各平台的lib文件）,已经上传到百度云，请下载好手动解压放到项目内。 下载地址:http://pan.baidu.com/s/1i579Fet