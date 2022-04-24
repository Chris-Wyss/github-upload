<table class="chaptertable" align="center" width="80%"><tr><td class="eventtd" align="left">
<font size=2>
<br>
<b>Welcome to CheckDNS!</b>
<br><br>
<b>What is CheckDNS ?</b>
<br>
CheckDNS is an automated tool to test DNS zone hosting.<br>
Just enter any domain name above (like "yourdomain.com") and you'll get a report showing possible problems with this domain.
<br><br>

<b>A bit of history and background.</b>
<br>
Once we spent a lot of time to detect and fight such DNS-related problems. 
<br>
Imagine typical situation: you as a systems administrator register new domain name (say, yourdomain.com), configure primary and secondary DNS servers, set up mail server to receive mails, make www.yourdomain.com  to point to your web-server - a lot of easy steps. So easy that nobody is willing to spend enough time doing it.<br>
<br>
However, one of Murphy's Laws says: "If anything can go wrong, it will. If anything just cannot go wrong, it will anyway". You can mistype name of mail server or name of secondary DNS. Another time your firewall can be blocking requests to name servers, so www.yourdomain.com doesn't open from "outside". And so on.
<br><br>
Hosted domain can even work, but have hidden problems - sometimes DNS is too reliable. Typical examples:
<br>
- In company X, backup MX  (mail server) was configured wrong. Everything was fine, until first mail server crashed. It took one day to bring server back online. During this day, backup MX was rejecting all incoming mails as SPAM. It would be much better to have no backup server than such one!
<br>
- Anther case: company Y didn't know that their primary DNS was not accessible from the Internet because of firewall configuration, and just secondary was working.  One day secondary DNS was shut down ("it's just secondary, nothing really important, let's upgrade it now") - with absolutely unexpected effect.
<br>
-One more: company Z moved primary to another IP, so secondary couldn't refresh zone copy any more. After expire period, secondary shut down zone automatically. This was recognised only when primary crashed because of DoS attack ("But it should have worked without primary, we have backup, don't we ?.")
<br><br>
All these cases illustrate one problem: there is no easy way to diagnose such problems (telnet, nslookup and dig can do it, but need time). 
<br>
CheckDNS is our solution of the problem.
</font>
</td></tr></table>