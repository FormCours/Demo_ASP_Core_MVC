CREATE FUNCTION [dbo].[GetDbSalt]()
RETURNS NVARCHAR(1000)
AS
BEGIN
	DECLARE @DbSalt NVARCHAR(1000);

	SET @DbSalt = '-mTfr-w-d2?b3wn$HbrRk%YhhCPF2quSyEaA*$?m$Z7!S*8!Wb4w&J#Jh+@NAQY&UP5U+e%M4#9SgaV@mMksA#3A?zrW3fw@V8b9hR&mvKwtyrbCUmWuEaXBcQ-KwsmD%aR7FRS2qVb+!k2FRqZGN3bM53p?XPAZNN5qZWpz8ZQZ576UR3x8gv+rJzbAc%9bmR4ybp$$ew#2DwzVN@3TnVY3Xk86w4+h4bdAxuPQRdHc@Wj6BngCF&dg-3s!xT?w7gj$kBddyw-YXc$wyggFYpFF$qu+4H455amcjefhh95-u9KJrY*T4PX6pZeFdQC?Q$njtWzcg$TD3bEJSfmput7#HYP#tGhK4e9yk5rebbMheHTq$YY8E#xbbk?2s-kGvB3nUwZ#?Gb8DdgUQ4-HJ2TA@gPjujpfn%bJD5Hp?g7Gxa2QfySJM$vqyv4SMB!zD&yKcPv-JyH7e%zkH5vadmyz$&hDwdS6+sKhA5f#tEW&4BwF9hdjHjxc?pqdD6XPmG-$R6@rZeFVa%q2X5AcvV!8mHV98@!aV*5+TW-prQF?PVb2$DTFPDWfb4xuV3xY7jacwRRy5f3Dxm4mpFQ&7z8ZYP#Yu+h5hhU35gBYF-8J?F22D#+CKnBg6FXtfPkkwShZZ*w9$AChyexg@QN6hcFCr!j9RNvrcPRBTbZbX7UMxSd86Ha*HG#KcKHs%3g!-KtejF$YVMtrD#sc&xnQ-5my3BEQBGbz-zxf8$C-!?N%nw#brW6E3J4WMC2x7sJ%x8EDBg4dSZ8Y$g#CW3pkr&-+5QwbXt8+fqyrRh#&E+p9&Vhp!Y3BdJtcnzQ!nbh7s$3n@#3VND$q5k22T!CeQVT&wv8tMU%jhMdqdfEjCq#uMQvXEsZgMxC+BQBSaWy8f$EDHdZcqV&4mNYMKp4uGV3T84!jsrA*n5H-N$C*Yfy-seraRrgh*Uyuky8c$nVW6kaNp5Gy5hF3ag#%u-3HQGN#fHpHr7!kXpU+f-k%';

	RETURN @DbSalt;
END
