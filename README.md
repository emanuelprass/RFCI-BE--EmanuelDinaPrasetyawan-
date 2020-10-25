# RFCI-BE--EmanuelDinaPrasetyawan-

Untuk test Sorting, code ada dalam file RFCI_1-Sorting.zip. Kemudian untuk test Simple App Debuging, code ada dalam file RFCI_3_SimpleAppDebugging.zip

< Markdown >

1.	Pada saat pertama kali menjalankan aplikasi, terdapat error cannot find module ‘express’. Hal ini terjadi karena belum terdapat module express yang terpasang
    o Resolve
      o	Install express dengan sintaks npm install express
      
2.	Setelah express berhasil di install, terdapat error cannot find module ‘dotenv’. Hal ini terjadi karena belum terdapat module dotenv yang terpasang.
    oResolve
      o	Install dotenv dengan sintaks npm install dotenv
      
3.	Setelah dotenv berhasil di install, terdapat error couldn’t find .env file. Hal ini mungkin terjadi karena file .env tidak ditemukan atau beberapa kemungkinan lain.
    o Resolve
      o	Comment code pada file codedebugging-master\src\config\index.js const envFound = dotenv.config(); if (envFound.error) {
        throw new Error("⚠️  Couldn't find .env file  ⚠️"); } kemudian ganti menjadi try { const envFound = dotenv.config(); }catch(error){ console.log(error);}
  
4.	Setelah itu terdapat error cannot find module ‘axios. Hal ini terjadi karena belum terdapat module axios yang terpasang.
    o Resolve
      o	Install axios dengan sintaks npm install axios
      
5.	Setelah semua berhasil di install saya menjalankan perintah nodemon app.js. Namun hasilnya tidak ada error, namun ada pesan app listening on http://localhost:undefined.
    Untuk hal tersebut saya kurang paham, karena pada setting port di file env port sudah di setting pada port 3000.

      

