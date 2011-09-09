// ATCBIND.h : main header file for the ATCBIND DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CATCBINDApp
// See ATCBIND.cpp for the implementation of this class
//

class CATCBINDApp : public CWinApp
{
public:
	CATCBINDApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
