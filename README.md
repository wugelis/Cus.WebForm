# 如何有架構性將現有 ASP.NET Web Form 轉換為 MVC？(範例程式)

# 具備分層架構的Northwind的WebForm訂單資料檔維護

課程連結：
https://dotblogs.com.tw/gelis/2015/06/23/151629

本課程的重點不在於轉換為 MVC 這件事，重點在於架構性的思考，筆者會先帶著大家將原本的網站分層、將各層 (Layer/Tier) 職責切割清楚，說明當我職責切分清楚時，前端其實不管是既有的 WebForm 應用程式，或是重新撰寫的 MVC 應用程式，都可以操作這個Services層

這一次，筆者將從頭帶著大家動手做。如何將一個現有的 Northwind 的訂單編輯程式(ASP.NET WebForm) 轉換為 ASP.NET MVC

本範例程式、將各層 (Layer/Tier) 職責切割清楚，說明當我職責切分清楚時，前端其實不管是既有的 WebForm 應用程式，或是重新撰寫的 MVC 應用程式，都可以操作這個Services層。

## 本軟體授權方式
# 本軟體使用 MIT 授權條款（Massachusetts Institute of Technology）, Copyright (C) 2017 Gelis Wu.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
