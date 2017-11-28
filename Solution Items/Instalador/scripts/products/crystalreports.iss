[CustomMessages]
crystal_title=Crystal Reports Client
crystal_size=60 MB - 80 MB


[Code]
const
	crystal_url = 'ftp://scinfo%40cacapava.net:scinfoftp@cacapava.net/D-e Brasil/CRRuntime_32bit_13_0_13.msi';
	crystal_url_64 = 'ftp://scinfo%40cacapava.net:scinfoftp@cacapava.net/D-e Brasil/CRRuntime_64bit_13_0_13.msi';

procedure creportsFull();
begin
	if (not IsWin64 and
	not RegKeyExists(HKLM, 'SOFTWARE\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Crystal Reports')) then

        AddProduct('CRRuntime_32bit_13_0_13.msi',
            '/qb',
            CustomMessage('crystal_title'),
            CustomMessage('crystal_size'),
            crystal_url,
            false, false);
	if (IsWin64 and
	not RegKeyExists(HKLM, 'SOFTWARE\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Crystal Reports')) then

        AddProduct('CRRuntime_64bit_13_0_13.msi',
            '/qb',
            CustomMessage('crystal_title'),
            CustomMessage('crystal_size'),
            crystal_url_64,
            false, false);
end;
