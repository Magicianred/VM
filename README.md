<!-- Logo -->
<p align="center">
  <a href="#">
    <img height="128" width="128" src="https://raw.githubusercontent.com/ancientproject/cli/master/resource/icon.png">
  </a>
</p>

<!-- Name -->
<h1 align="center">
  AncientVM 🔥
</h1>
<!-- desc -->
<h4 align="center">
  8bit Virtual Machine & Ancient Assembler-style language
</h4>

<!-- classic badges -->
<p align="center">
    <a href="https://dev.azure.com/0xF6/AncientVM/_build">
    <img src="https://dev.azure.com/0xF6/AncientVM/_apis/build/status/0xF6.ancient_cpu?branchName=master">
  </a>
  <a href="#">
    <img src="http://img.shields.io/:license-MIT-blue.svg">
  </a>
<a href="https://app.fossa.io/projects/git%2Bgithub.com%2F0xF6%2Fancient_cpu?ref=badge_shield" alt="FOSSA Status"><img src="https://app.fossa.io/api/projects/git%2Bgithub.com%2F0xF6%2Fancient_cpu.svg?type=shield"/></a>
  <a href="https://github.com/0xF6/ancient_cpu/releases">
    <img src="https://img.shields.io/github/release/0xF6/ancient_cpu.svg?logo=github&style=flat">
  </a>
  <a href="https://www.codacy.com/app/0xF6/cpu_4bit?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=0xF6/cpu_4bit&amp;utm_campaign=Badge_Grade"><img src="https://api.codacy.com/project/badge/Grade/e033b506944447289b2ef39478fc8234"/></a>
  </a>
</p>

<!-- popup badges -->
<p align="center">
   <a href="https://marketplace.visualstudio.com/items?itemName=rijndael.ancient-asm">
    <img alt="Visual Studio Marketplace Version" src="https://img.shields.io/visual-studio-marketplace/v/rijndael.ancient-asm.svg?style=popout-square&logo=visual-studio-code&logoColor=%23CCC">
  </a>
  <a href="https://t.me/ivysola">
    <img src="https://img.shields.io/badge/Ask%20Me-Anything-1f425f.svg?style=popout-square&logo=telegram">
  </a>
</p>

<!-- big badges -->
<p align="center">
  <a href="#">
    <img src="https://forthebadge.com/images/badges/made-with-c-sharp.svg">
    <img src="https://forthebadge.com/images/badges/designed-in-ms-paint.svg">
    <img src="https://forthebadge.com/images/badges/ages-18.svg">
    <img src="https://ForTheBadge.com/images/badges/winter-is-coming.svg">
    <img src="https://forthebadge.com/images/badges/gluten-free.svg">
  </a>
</p>

![image](https://user-images.githubusercontent.com/13326808/60311909-e71fa900-9961-11e9-96f0-bf4c4a45681c.png)


<details>
  <summary>Spoiler</summary>
  
![meme](https://user-images.githubusercontent.com/13326808/72352994-55586d00-36f4-11ea-8667-39475c9fd69f.png) 

  by 
 [@ViktorChernyaev](https://github.com/ViktorChernyaev)
</details>


---

> Ancient VM proof of concept of the language, toolskit, virtual machine and ecosystem
> A VM with 50+ instructions, SIMD Vector calculation, modularity, language and compiler, cli tool and package register of modules and extensions

---


# 📡 Installation

```bash
$ yarn global add @rune-temp/cli
$ rune install vm
```

# 💻 OS Support

OS                            | Version                       | Architectures
------------------------------|-------------------------------|----------------
Windows 10                    | 1607+                         | x64, ARM32
OSX                           | 10.14+                        | x64            
Linux                         |                               | x64, ARM32, ARM64


##### Env flags 
```yaml
- VM_TRACE         : 1\0    - enable or disable trace logging (default 0)
- VM_ERROR         : 1\0    - enable or disable error logging (default 1)
- VM_KEEP_MEMORY   : 1\0    - when halt cpu disable or enable clearing memory table (default 0 - clearing)
- VM_MEM_FAST_WRITE: 1\0    - enable or disable fast-write mode to devices (see fast-mode addressing)
- C69_BIOS_HPET    : 1\0    - enable using hardware hper timer (default 0)
- VM_WARMUP_DEV    : 1\0    - enable warm-up devices on plug-connect (default 1)
- VM_SHUTDOWN_DEV  : 1\0    - enable shutdown devices on halting processor (default 1)
- VM_SYM_ENCODING  : "utf8" - set encoding of debug symbols (default "IBM037")
```

##### Memory table: 
  
example:  
```assembler
.ldx &(0x11) <| $(0x0) - disable trace
``` 
list: 
```yaml
- 0x11 : 1\0 - enable or disable trace logging (default 0)
- 0x12 : 1\0 - enable or disable error logging (default 1)
- 0x13 : 1\0 - when halt cpu disable or enable clearing memory table (default 0 - clearing)
- 0x14 : 1\0 - enable or disable fast-write mode to devices (see fast-mode addressing)
- 0x18 : 1\0 - enable float-mode
- 0x19 : 1\0 - enable stack-forward flag
- 0x20 : 1\0 - control stack flag (north flag)
- 0x21 : 1\0 - control stack flag (east flag)
- 0x22 : 1\0 - bios read-access flag
```

##### Bios table: 

###### public memory [READ]: 
```yaml
- 0x00 - return current ticks (u32)
- 0x01 - return hpet enabled or not
- 0x02 - return memory channel
- 0xFX - private memory randge
```
###### private memory [READ]:
```yaml
- 0xF1 : return hpet enabled or not
- 0xF2 : return use virtual stack forwarding or not
- 0xF3 : return use forward in standalone memory sector or not
- 0xF6 : return using guarding with violation memory write or not (default bios_guard_flag has enabled)
```

###### public\private memory [WRITE]: 
  
```yaml
- 0x1 : 1\0 - set hpet use or not (default value depends on the firmware)
- 0xA : reseting hpet and system timers
- 0xD : call system interrupts for N-value ms
- 0xC : call clearing RAM (need enabled bios_guard_flag, and disabled southFlag)
- 0xF : set at private memory range value (need southFlag)
```


##### remarks:
###### fast-mode addressing        
`Write speedUp to device memory (x12~ times), but disables the ability to write to certain sections of device memory.`
###### READ\WRITE operation for bios
`Need southFlag enabled for READ\WRITE operation for private memory, otherwise will be calling CorruptedMemoryException and halting cpu`
###### bios_guard_flag
`Some memory segments are not allowed to READ\WRITE operation when bios_guard_flag is enabled ` 
###### create external function   
`todo :)` 

## Command docs

#### No operation
```asm
.nop
```
#### Warm up VM [obsolete]
```asm
.warm
```
#### Shutdown VM
```asm
.halt
```
#### Direct load index
Load value into cell
```asm
.ldi 
```
###### Examples:
Local 0xF value into [0x0] cell
```asm
.ldi &(0x0) <| $(0xF)
```
##### Remarks:
Only range cell 0x0-0xF, value 0x0-0xFF

#### Direct load index extended
Load value into cell
```asm
.ldx 
```
###### Examples:
Load 0xF value into [0x0] cell
```asm
.ldx &(0x0) <| $(0xF)
```
##### Remarks:
Range cell 0x0-0xFF, value 0x0-0xFF

#### Move classic [obsolete]
Load value into device
```asm
.mva &(0x0) &(0x5) <| $(0xA)
```
###### Examples:
Send 0xA value into [0x0] device and [0x5] action
```asm
.mva &(0x0) &(0x5) <| $(0xA)
```
##### Remarks:
Range device 0x0-0xF, action 0x0-0xF, value 0x0-0xFFFF

#### Write to device
Load value into device
```asm
.wtd &(0x00) &(0x55) <| $(0xAF)
```
###### Examples:
Send 0xA value into [0x0] device and [0x5] action
```asm
.wtd &(0x0) &(0x5) <| $(0xA)
```
##### Remarks:
Range device 0x0-0xFF, action 0x0-0xFF, value 0x0-0xFF
Result stage into stack

#### Read to device
Load value into device
```asm
.rfd &(0x0) &(0x5)
```
###### Examples:
Read from 0x5 action and 0x0 device, result stage into stack
```asm
.rfd &(0x0) &(0x5)
```
##### Remarks:
Range device 0x0-0xFF, action 0x0-0xFF
Result stage into stack

##### Remarks:
Range device 0x0-0xFF, action 0x0-0xFF, value 0x0-0xFF
Result stage into stack

#### Read to device
Load value into device
```asm
.rfd &(0x0) &(0x5)
```
###### Examples:
Read from 0x5 action and 0x0 device, result stage into stack
```asm
.rfd &(0x0) &(0x5)
```
##### Remarks:
Range device 0x0-0xFF, action 0x0-0xFF
Result stage into stack


## History

Once i read an [article on Wikipedia](https://en.wikibooks.org/wiki/Creating_a_Virtual_Machine/Register_VM_in_C) about writing custom VM and interpreter bytecode.    
So, i wanted to give it a try.
Initially, i planned to write a 4-bit CPU emulator, afterwards i wrote it - but with the development of the source code, bit rate of instructions increased, and emulator has a programming language that is very similar to Assembler language (and CSS, yeah).    
It was a wonderful experience, i faced unusual problems and came up with quite unusual solutions.   
Since then, i continued to develop and improve different kinds of features in this project afterwards.  
I do not pursue any goals (except of course vm speed and language usability), and i do not expect my VM to be useful - but if you have any ideas on how to improve the project I’d be happy to hear from you.

[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2F0xF6%2Fancient_cpu.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2F0xF6%2Fancient_cpu?ref=badge_large)

<p align="center">
   <a href="https://ko-fi.com/P5P7YFY5">
    <img src="https://www.ko-fi.com/img/githubbutton_sm.svg">
  </a>
</p>
